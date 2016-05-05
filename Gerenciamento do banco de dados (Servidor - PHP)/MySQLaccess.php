<?php
	function conecxao(){
		//$con = mysqli_connect("localhost", "User", "user", "user");
		$con = mysqli_connect("mysql.hostinger.com.br", "u377658281_lemon", "lab14xadrez", "u377658281_banco");
		if (mysqli_connect_errno())
			die("error nº".mysqli_connect_errno() ." - ". mysqli_connect_error());
		mysqli_query($con,"SET NAMES 'utf-8'");
		mysqli_query($con,"SET character_set_conection=utf8");
		mysqli_query($con,"SET character_set_client=utf8");
		mysqli_query($con,"SET character_set_results=utf8");
		return $con;
	}

	function n_linhas(){	//conta o numero de linhas
		$con2 = conecxao();
		$all = mysqli_query($con2, "SELECT * FROM partida0");		//select all lines
		$n = mysqli_num_rows($all);									//take the number of lines

		mysqli_free_result($all);
		mysqli_close($con2);
		return $n;
	}

	function do_undo(){
		$con3 = conecxao();
		$a = mysqli_query($con3, "SELECT dado FROM partida0 WHERE id=1");		//retorna 1 para "DO" e 0 para "UNDO"
		$b = mysqli_fetch_assoc($a);
		if ($b['dado'] == "DO") {
			mysqli_close($con3);
			return "1";
		}
		mysqli_close($con3);
		return "0";
	}

	function trocar_jogador($equipe, $d_u){
		$con4 = conecxao();
		if ($equipe == "BR") {
			if( (mysqli_query($con4,"UPDATE partida0 SET dado='DONEB' WHERE id=3") && mysqli_query($con4,"UPDATE partida0 SET dado='MOVEF' WHERE id=2") ) && mysqli_query($con4,"UPDATE partida0 SET dado='$d_u' WHERE id=1"))
				$x = true;	//inseridos com sucesso
			else
				$x = false;		//falha na inserlção
		} else {	//$equipe == "FR"
			if( (mysqli_query($con4,"UPDATE partida0 SET dado='DONEF' WHERE id=2") && mysqli_query($con4,"UPDATE partida0 SET dado='MOVEB' WHERE id=3") ) && mysqli_query($con4,"UPDATE partida0 SET dado='$d_u' WHERE id=1"))
				$x = true;	//inseridos com sucesso
			else
				$x = false;		//falha na inserlção
		}
		
		mysqli_close($con4);
		return $x;
	}

	$conn = conecxao();

	if (isset($_POST['mover'])) {
		$equipe = $_POST['mover'];
		if (isset($_POST['m0'])) {
			$m0 = $_POST['m0'];
			$n = n_linhas() + 1;
			$status = true;
			if (mysqli_query($conn,"INSERT INTO partida0(id, dado) VALUES ('$n', '$m0')")) {
				if(isset($_POST['m1'])){
					$n++;
					$m1 = $_POST['m1'];
					if (mysqli_query($conn,"INSERT INTO partida0(id, dado) VALUES ('$n', '$m1')")) {
					}else{
						echo ("error=".mysqli_error($conn)."&&");
						$status = false;
					}
					unset($_POST['m1']);
				}
			} else {
				echo ("error=".mysqli_error($conn)."&&");
				$status = false;
			}
			unset($_POST['m0']);
			
			if ($status) {
				if(trocar_jogador($equipe, "DO"))
					echo "status=1";
				else
					echo "status=-1";
			} else
				echo "status=0";
		}
		unset($_POST['mover']);
	}

	else if (isset($_POST['undo'])) {
		$equipe = $_POST['undo'];

		if (isset($_POST['n'])) {
			$n = $_POST['n'];
			$ultimo = n_linhas();		//take the last line

			if ($n == '1') {
				if (mysqli_query($conn,"DELETE FROM partida0 WHERE id= ($ultimo)")) {
					if(trocar_jogador($equipe, "UNDO"))
						echo "status=1";
					else
						echo "status=-1";
				} else
					echo "status=0";
			} else if($n == '2'){
				if (mysqli_query($conn,"DELETE FROM partida0 WHERE id= ($ultimo)") && mysqli_query($conn,"DELETE FROM partida0 WHERE id= ($ultimo - 1)")) {
					if(trocar_jogador($equipe, "UNDO"))
						echo "status=1";
					else
						echo "status=-1";
				} else
					echo "status=0";
			} else if($undo_n == '0')
				echo "errorn=2";
			else
				echo "errorn=3";
			
			unset($_POST['n']);
		}
		unset($_POST['undo']);
	}

	else if (isset($_POST['team'])) {
		$team = $_POST['team'];

		if ($team == "BR") {		//consulta feita pelos brasileiros
			$state = mysqli_query($conn, "SELECT dado FROM partida0 WHERE id = 3");	//DONEB = esperar; MOVEB = mover
			$s = mysqli_fetch_assoc($state);
			if ($s['dado'] == "MOVEB") {
				echo ("tstate=1&&doundo=".do_undo());		//1 para mover e 0 para esperar		&&		1 para "DO" e 0 para "UNDO"
			}
			else{
				echo ("tstate=0");
			}
		} else {				//consulta feita pelos franceses
			$state = mysqli_query($conn, "SELECT dado FROM partida0 WHERE id = 2");	//DONEF = esperar; MOVEF = mover
			$s = mysqli_fetch_assoc($state);
			if ($s['dado'] == "MOVEF") {
				echo ("tstate=1&&doundo=".do_undo());		//1 para mover e 0 para esperar		&&		1 para "DO" e 0 para "UNDO"
			}
			else{
				echo ("tstate=0");
			}
		}

		mysqli_free_result($state);
		unset($_POST['team']);
	}

	else if (isset($_POST['readn'])) {
		$movs = $_POST['readn'];														//movs =  number of movs.
		$list = mysqli_query($conn, "SELECT * FROM partida0 WHERE id > (3+$movs)");		//list =  list of new movs.
		$newmovs = mysqli_num_rows($list);												//newmovs = number of new movs.
		if ($newmovs>2) {
			echo "errorn=1";															//error 1 = more than 2 movs.
		}else if ($newmovs>0) {
			echo "n=".$newmovs;
			for ($i=0; $i < $newmovs && $res = mysqli_fetch_assoc($list); $i++) { 
				echo "&&m".$i.'='.$res['dado'];
			}
		} else if ($newmovs == 0) {
			echo "n=0";
		}

		mysqli_free_result($list);
		unset($_POST['readn']);
	}

	else if (isset($_POST['readall'])) {												//send all table
		$list = mysqli_query($conn, "SELECT * FROM partida0");
		$n = mysqli_num_rows($list);
		echo "n=".$n;
		for ($i=0; $i < $n && $res = mysqli_fetch_assoc($list); $i++) { 
			echo "&&l".$i."=".$res['dado'];
		}
		
		mysqli_free_result($list);
		unset($_POST['readall']);
	}

	else {
    	echo ("It works!");
    }

    mysqli_close($conn);

/*
errorn
1	= trying to do more than 2 movs.
2	= trying to undo more than 0 movs.
3	= trying to undo more than 2 movs.

status
1	= dados inseridos com sucesso
0	= nenhum dado inserido
-1	= apenas parte dos dados inseridos
*/
?>