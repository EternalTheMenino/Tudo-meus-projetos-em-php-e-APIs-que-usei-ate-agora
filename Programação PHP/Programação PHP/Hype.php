<?php  

echo "
 _   ___   _______ _____ 
| | | \ \ / / ___ \  ___|
| |_| |\ V /| |_/ / |__  
|  _  | \ / |  __/|  __| 
| | | | | | | |   | |___ 
\_| |_/ \_/ \_|   \____/ 
        
 - TheHype Encrypt v0.1a                        
                         \n\n
";
	
$ec = new Encode();


	/**
 * Returns an encrypted & utf8-encoded
 */

#
#	if(count($argv)==5) {
		
		if ($argv[2] == "--encrypt"){
if(file_exists($argv[1])){


					echo "TheHype Encrypt v0.1a\n";
echo "Normal text: \n".file_get_contents($argv[1])."\n"; 
echo "Encrypt: \n".$ec->E(file_get_contents($argv[1]));


}else{
	echo"ERRO: Esta arquivo não existe!";
}
		}else if($argv[2] == "--decrypt"){
			if(file_exists($argv[1])){
			
echo "Normal text: \n".file_get_contents($argv[1])."\n"; #


	echo "Encrypt: \n".$ec->D(file_get_contents($argv[1]));


	}else{
	echo"ERRO: Esta arquivo não existe!";
}	

	} else {
		print("Syntax: php " . $_SERVER['SCRIPT_NAME'] . "  [file] [method] \n --encrypt - for encrypt text file \n --decrypt - for decrypt text file ");
	}

define("ENCRYPTION_KEY", "!!%#$%^&*");
class Encode {
	function E($word) {
		$letters=array("a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","A","B","C","D","E","F","G","H","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","#","=");
		$to=array("!%01","!%02","!%03","!%04","!%05","!%06","!%07","!%08","!%09","!%10","!%11","!%12","!%13","!%14","!%15","!%16","!%17","!%18","!%19","!%55","!%21","!%22","!%23","!%24","!%25","!%26","!%27","!%28","!%29","!%30","!%31","!%32","!%33","!%34","!%35","!%36","!%37","!%38","!%39","!%40","!%41","!%42","!%43","!%44","!%45","!%46","!%47","!%48","!%49");
		return str_replace($letters,$to,$word);
	}
	function D($hash) {
		$to=array("a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","A","B","C","D","E","F","G","H","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","#","=");
		$letters=array("!%01","!%02","!%03","!%04","!%05","!%06","!%07","!%08","!%09","!%10","!%11","!%12","!%13","!%14","!%15","!%16","!%17","!%18","!%19","!%55","!%21","!%22","!%23","!%24","!%25","!%26","!%27","!%28","!%29","!%30","!%31","!%32","!%33","!%34","!%35","!%36","!%37","!%38","!%39","!%40","!%41","!%42","!%43","!%44","!%45","!%46","!%47","!%48","!%49");
		return str_replace($letters,$to,$hash);
	}
}


?>



