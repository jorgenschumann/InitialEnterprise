var SiteScript;

(function (SiteScript) {
    var BusyIndicator = (function () {
        function BusyIndicator() {
        }    

        BusyIndicator.showMessageBox = function (element) {
            $(element).modal({ backdrop: 'static' });
        };
      
        BusyIndicator.showBusyIndicator = function (element) {
            $(element).modal({ backdrop: 'static', keyboard: false });
        };
   
        BusyIndicator.hide = function (element) {
            $(element).modal('hide');
        };         

        return BusyIndicator;
    })();

    SiteScript.BusyIndicator = BusyIndicator;
})(SiteScript || (SiteScript = {}));
