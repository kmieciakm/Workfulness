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

window.setTrackAtTime = (percent) => {
    console.log(percent);
    let trackTime = track.duration * percent / 100;
    track.currentTime = trackTime;
}

window.getElapsedTimeInPercents = () => {
    return track.currentTime / track.duration * 100;
}