window.audioPlayer = {
    track: document.createElement('audio'),
    dotnetHelper: undefined,

    attachSongToAudio: function (songUrl) {
        this.track.src = songUrl;
        this.track.load();
        this.track.currentTime = 0;
    },
    play: function() {
        this.track.play();
    },
    pause: function() {
        this.track.pause();
    },
    setTrackAtTime: function (percent) {
        let trackTime = this.track.duration * percent / 100;
        this.track.currentTime = trackTime;
    },
    getElapsedTimeInPercents: function() {
        let elapseTime = Math.ceil(this.track.currentTime / this.track.duration * 100);

        if (elapseTime >= 100) {
            this.dotnetHelper.invokeMethodAsync('SongFinished');
        }

        if (isNaN(elapseTime))
            return 0;
        return parseInt(elapseTime);
    },
    setDotnetHelper: function (dotnetHelper) {
        this.dotnetHelper = dotnetHelper;
    }
};