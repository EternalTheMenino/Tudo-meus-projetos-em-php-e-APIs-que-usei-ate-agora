<?php
     $view = new Visitas();
  echo "Total de views: ".$view->getView();



   class Visitas {
    
    private $username = "root";
    private $password = "";
    private $host = "localhost";
    private $dbname = "bancocontador";
    
    protected $conn;
    
    public function __construct() {
      $this->conn = mysqli_connect($this->host,$this->username,$this->password,$this->dbname);
    }
    
    public function getView() {
      $result_view = $this->get();
      
      $num = $result_view['view']+1;
      
      $this->set($num);

      return $num;
    }
    private function get(){
      $result_query = mysqli_query($this->conn,"SELECT * FROM contador");
      $result = mysqli_fetch_assoc($result_query);
      return $result;
    }
    private function set($num){
      $result_query = mysqli_query($this->conn,"UPDATE `contador` SET `view`= $num WHERE `id`= 0");
    }
  }