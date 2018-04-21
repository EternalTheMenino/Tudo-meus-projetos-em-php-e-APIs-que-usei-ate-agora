<?php
	
	$host		= "themenino.net.mysql";
	$usuario	= "themenino_net_video_iframe";
	$senha		= "video_iframe";
	$banco		= "themenino_net_video_iframe";

	$conexao	= mysqli_connect($host, $usuario, $senha, $banco) or die("Erro ao se conectar com o MySQL.");

?>