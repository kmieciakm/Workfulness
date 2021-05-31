window.app = {
    dotnetHelper: undefined,
    callResize: function () {
        if (this.dotnetHelper != null && this.dotnetHelper != undefined) {
            this.dotnetHelper.invokeMethodAsync('OnPageResized', window.innerWidth, window.innerHeight);
        }
    },
    setDotnetHelper: function (dotnetHelper) {
        this.dotnetHelper = dotnetHelper;
    }
};