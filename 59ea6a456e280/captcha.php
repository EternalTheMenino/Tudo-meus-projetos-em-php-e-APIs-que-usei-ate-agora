<?php
$view = new Visitas();
//generate image
$im = imagecreatetruecolor(124, 40);
$foreground = imagecolorallocate($im, 0, 0, 0);
$shadow = imagecolorallocate($im, 173, 172, 168);
$background = imagecolorallocate($im, 255, 255, 255);

imagefilledrectangle($im, 0, 0, 200, 200, $background);

// use your own font!
$font = 'monofont.ttf';

//draw text:
imagettftext($im, 35, 0, 9, 28, $shadow, $font, $view->getView());
imagettftext($im, 35, 0, 2, 32, $foreground, $font, $view->getView());     

// prevent client side  caching
header("Expires: Wed, 1 Jan 1997 00:00:00 GMT");
header("Last-Modified: " . gmdate("D, d M Y H:i:s") . " GMT");
header("Cache-Control: no-store, no-cache, must-revalidate");
header("Cache-Control: post-check=0, pre-check=0", false);
header("Pragma: no-cache");

//send image to browser
header ("Content-type: image/png");
imagepng($im);
imagedestroy($im);


   class Visitas {
    
    private $username = "blackper_personne";
    private $password = "M9WkE7ZyKFNPn055ex";
    private $host = "localhost";
    private $dbname = "blackper_projetos";
    
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
?>
