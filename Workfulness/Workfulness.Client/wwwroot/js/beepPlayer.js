window.beepPlayer = {
    track: document.createElement('audio'),
    playBeep: function (beepUrl, dotnetHelper) {
        this.track.src = beepUrl;
        this.track.load();
        this.track.currentTime = 0;
        this.track.onended = function () { dotnetHelper.invokeMethodAsync('SongFinished'); };
        this.track.play();
    }
};