<?php
	function conecxao(){
		$con = mysqli_connect("localhost", "User", "user", "user");
		if (mysqli_connect_errno())
			die("error nº".mysqli_connect_errno() ." - ". mysqli_connect_error());
		mysqli_query($con,"SET NAMES 'utf-8'");
		mysqli_query($con,"SET character_set_conection=utf8");
		mysqli_query($con,"SET character_set_client=utf8");
		mysqli_query($con,"SET character_set_results=utf8");
		return $con;
	}
	$conn = conecxao();

	//void main()
	if (isset($_POST['get'])){
        echo ("Read: ".$_POST['get']."\r");

		//$conn = conecxao();
		$retorno = mysqli_query($conn, "SELECT * FROM partida0 WHERE id > 3");
		echo (mysqli_num_rows($retorno)." movimentos:\r");
		while($res = mysqli_fetch_assoc($retorno)){
			echo (($res['id']-3)." - ".$res['dado']."\r");	//$res['id']." - ".
		}
		
		mysqli_free_result($retorno);
		mysqli_close($conn);
        unset($_POST['get']);
    }else if(isset($_POST['sinc'])){

    	$data = $_POST['sinc'];
    	$retorno = mysqli_query($conn, "SELECT * FROM partida0 WHERE id > (3+$data)");
    	$n = mysqli_num_rows($retorno);
    	if($n > 0){
    		echo (($n - $data)." novos movimentos\r");
    		while($res = mysqli_fetch_assoc($retorno)){
				echo (($res['id']-3)." - ".$res['dado']."\r");	//$res['id']." - ".
			}
    	}else
    		echo "no movs";

    	/*$retorno = mysqli_query($conn, "SELECT * FROM partida0 WHERE id > 3");
		$n = mysqli_num_rows($retorno);
		echo (($n - $data)." novos movimentos\r");
		if($n > $data){
			$retorno = mysqli_query($conn, "SELECT * FROM partida0 WHERE id > (3+$data)");
			while($res = mysqli_fetch_assoc($retorno)){
				echo (($res['id']-3)." - ".$res['dado']."\r");	//$res['id']." - ".
			}
		}*/

    	unset($_POST['sinc']);
    }else if (isset($_POST['put'])){
        echo ("Send(".$_POST['put']."): \r");
		
		//$conn = conecxao();
		$recebido = $_POST['put'];
        if (mysqli_query($conn,"INSERT INTO partida0(dado) VALUES ('$recebido')")) {
			echo ("dado inserido com sucesso. id = ".mysqli_insert_id($conn));
		}else{
			echo ("erro de inserção: ".mysqli_error($conn));
		}

		mysqli_close($conn);
        unset($_POST['put']);
    }else if(isset($_POST['sys'])){
    	
    	//$conn = conecxao();
    	$data = $_POST['sys'];
    	if($data == "DONEF") {
    		mysqli_query($conn,"UPDATE partida0 SET dado='DONEF' WHERE id=2");
			mysqli_query($conn,"UPDATE partida0 SET dado='MOVEB' WHERE id=3");
			echo "DONEF";
    	}else if($data == "DONEB") {
    		mysqli_query($conn,"UPDATE partida0 SET dado='DONEB' WHERE id=3");
			mysqli_query($conn,"UPDATE partida0 SET dado='MOVEF' WHERE id=2");
			echo "DONEB";
    	}
    	mysqli_close($conn);
        unset($_POST['sys']);
    }else{
    	echo ("comando inválido");
    }
?>