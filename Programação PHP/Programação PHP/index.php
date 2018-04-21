<?php

  $conexao  = mysqli_connect("localhost", "root", "vertrigo", "blackviewbot") or die("Erro ao se conectar com o MySQL.");

				$sql = mysqli_query($conexao, 'SELECT * FROM `videos` WHERE 1');
				while($data = mysqli_fetch_assoc($sql)) {

?>
<br>
<div id="view" id="player"></div>
<script>
      var tag = document.createElement('script');
      tag.src = "https://www.youtube.com/iframe_api";
      var firstScriptTag = document.getElementsByTagName('script')[0];
      firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
      var player;
      function onYouTubeIframeAPIReady() {
        player = new YT.Player('player', {
          height: '315',
          width: '560',
          videoId: '<?php echo $data["id_yt"]; ?>',
          events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
          }
        });
      }
     
      function onPlayerReady(event) {
           event.target.setVolume(0);
       event.target.playVideo();
      }
      var done = false;
      function onPlayerStateChange(event) {
        if (event.data == YT.PlayerState.PLAYING && !done) {

                  done = true;
                 // location.reload();
        }
           event.target.setVolume(0);
      }
</script>

<style type="text/css">
 view{
   opacity: 0.1;
 }
</style>
<?php
  } 


  ?>


