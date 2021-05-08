window.beepPlayer = {
    track: document.createElement('audio'),
    dotnetHelper: undefined,

    playBeep: function (beepUrl) {
        this.track.src = beepUrl;
        this.track.load();
        this.track.currentTime = 0;
       // this.trackl.onended = (event) => { this.dotnetHelper.invokeMethodAsync('SongFinished'); };
   //     this.track.addEventListener('ended', function () { this.dotnetHelper.invokeMethodAsync('SongFinished'); console.log('elo') });
     //   this.track.onended = function (event) {
       //     this.dotnetHelper.invokeMethodAsync('SongFinished');

        //}
       // this.track.onended = this.invokeSongFinished;
     //   this.track.onended = () => { this.invokeSongFinished; }
       // this.track.onended = () => console.log('track onended');
        this.track.play();
    },
    setDotnetHelper: function (dotnetHelper) {
        this.dotnetHelper = dotnetHelper;
    },
    invokeSongFinished: function () {
        this.dotnetHelper.invokeMethodAsync('SongFinished');
    }
};