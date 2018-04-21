<?php
$host = "localhost";
$user = "blackper_personne";
$pass = "ufeTOKWnXt2v8H5uy7";
$db = "blackper_projetos";

    $conexao    = mysqli_connect($host, $user, $pass, $db) or die("Erro ao se conectar com o MySQL.");
    $sql = mysqli_query($conexao, 'SELECT * FROM `bp_update` WHERE 1');

    while($data = mysqli_fetch_assoc($sql)) {
        if (time() > $data['datafinal']){
die("Sua Key venceu compre novamente pelo skype: live:blackpersonne_666");
        }
     

    }























 ?>
