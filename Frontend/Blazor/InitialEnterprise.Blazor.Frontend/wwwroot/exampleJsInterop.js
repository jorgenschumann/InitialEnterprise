window.exampleJsFunctions = {
    showPrompt: function (text) {
        return prompt(text, 'Type your name here');
    },
    displayWelcome: function (welcomeMessage) {
        document.getElementById('welcome').innerText = welcomeMessage;
    },
    returnArrayAsyncJs: function () {
        DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
            .then(data => {
                data.push(4);
                console.log(data);
            });
    },
    sayHello: function (dotnetHelper) {
        return dotnetHelper.invokeMethodAsync('SayHello')
            .then(r => console.log(r));
    },
   toggleSidebar: function () {
        $('.visible.example .ui.sidebar')
            .sidebar({
                context: '.wrapper'
            }).sidebar('toggle');

        //// Override the default dimmer page behaviour for Sidebar 
        //$('.visible.example .ui.sidebar')
        //    .sidebar({
        //        context: '.wrapper',
        //        dimPage: false,
        //        closable: false
        //    })
        //    .sidebar('attach events', '#vk-header-icon-a')
        //    .sidebar('setting', 'transition', 'push');
    }
};

