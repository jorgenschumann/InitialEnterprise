var SiteScript;

(function (SiteScript) {
    var BusyIndicator = (function () {
        function BusyIndicator() {
        }    

        BusyIndicator.showMessageBox = function (element) {    
            $(element).addClass('active');
        };
      
        BusyIndicator.showBusyIndicator = function (element) {
            $(element).addClass('active');
        };
   
        BusyIndicator.hide = function (element) {          
            $(element).removeClass('active');
        };         

        return BusyIndicator;
    })();

    SiteScript.BusyIndicator = BusyIndicator;
})(SiteScript || (SiteScript = {}));
