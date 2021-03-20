let track = document.createElement('audio');

window.attachSongToAudio = (songUrl) => {
    track.src = songUrl;
    track.load();
    track.currentTime = 0;
}

window.play = () => {
    track.play();
}

window.pause = () => {
    track.pause();
}

window.setTrackAtTime = (percent) => {
    let trackTime = track.duration * percent / 100;
    track.currentTime = trackTime;
}

window.getElapsedTimeInPercents = () => {
    let elapseTime = Math.ceil(track.currentTime / track.duration * 100);

    if (isNaN(elapseTime))
        return 0;
    return parseInt(elapseTime);
}