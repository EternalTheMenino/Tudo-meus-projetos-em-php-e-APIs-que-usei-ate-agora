<?php
$id = "0";
$randvideo = rand(1,2);

switch ($randvideo) {
  case 1:
$id = "Rs2lIhq8Fpw";
    break;
  case 2:
$id = "7Z0rM8oT71E";
    break;
  
}
?>

<div id="player"></div>
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
          videoId: '<?php echo $id; ?>',
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
        }
           event.target.setVolume(0);
      }
</script>