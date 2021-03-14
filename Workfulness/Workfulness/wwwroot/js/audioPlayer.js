let track = document.createElement('audio');

window.play = (songUrl) => {
    track.src = songUrl;
    track.load();
    track.play();
}

window.replay = () => {
    track.play();
}

window.pause = () => {
    track.pause();
}