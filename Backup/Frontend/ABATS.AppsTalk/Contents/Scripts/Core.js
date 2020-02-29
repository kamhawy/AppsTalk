function ShowWindowRegular(title, windowName, url, width, height, extraFeatures) {
    var features = 'height=' + height + ',width=' + width + ',resizable=1,scrollbars=1,statusbar=1';

    if (extraFeatures != null) {
        features += ',' + extraFeatures;
    }

    var newwindow = window.open(url, windowName, features);

    if (window.focus) {
        newwindow.focus();
    }
}

function OpenNewWindow(url) {
    window.open(url, '_blank');
    return false;
}

function CloseWindowRegular() {
    window.close();
}

function pageLoad(sender, args) {
    theForm.onkeypress = function (e) {
        e = e || window.event;
        if (e.keyCode == 13) {
            if (e.preventDefault) e.preventDefault();
            if (e.stopPropagation) e.stopPropagation();
            e.cancelBubble = false;
            return false;
        }
    }
}

function addCssClass(className, element) {
    if (element.className.indexOf(className) < 0) {
        element.className = element.className + " " + className;
    }
}

function removeCssClass(className, element) {
    element.className = element.className.replace(className, "").replace(/^\s+/, '').replace(/\s+$/, '');
}

function GetSiteRootURL() {
    return document.location.protocol + '//' + document.location.hostname + '/ABATS.AppsTalk';
}

/*------------------*/
/* Custom Functions */
/*------------------*/

function RenderMenu() {
    $("#ulMenu").kendoMenu({
        dataSource: [
            {
                text: "AppsTalk", imageUrl: "/ABATS.AppsTalk/Contents/Images/apps.png", url: "/ABATS.AppsTalk/Default.aspx"
            },
            {
                text: "Tools", imageUrl: "/ABATS.AppsTalk/Contents/Images/tools.png",
                items: [
    			    { text: "Execute Integration Process", url: "/ABATS.AppsTalk/Views/Tools/ExecuteIntegrationProcess.aspx" },
                    { text: "Integration Process History", url: "/ABATS.AppsTalk/Views/Tools/IntegrationProcessHistory.aspx" }
                ]
            },
            {
                text: "Administration", imageUrl: "/ABATS.AppsTalk/Contents/Images/admin.png",
                items: [
                    { text: "Applications", url: "/ABATS.AppsTalk/Views/Admin/Applications/ApplicationsList.aspx" },
                    { text: "Integration Processes", url: "/ABATS.AppsTalk/Views/Admin/IntegrationProcesses/IntegrationProcessesList.aspx" }
                ]
            },
        ]
    });
    }

function ShowApplicationEndPointView(ApplicationEndPointID, UIMode, ApplicationID) {
    var url = GetSiteRootURL() + '/Views/Admin/Applications/ApplicationEndPointView.aspx?ApplicationEndPointID=' + ApplicationEndPointID + '&UIMode=' + UIMode + '&ApplicationID=' + ApplicationID;
    ShowWindowRegular('Application End-Point', 'windowApplicationEndPoint', url, 1000, 600, null);
}

function ShowIntegrationAdapterView(IntegrationAdapterID, UIMode, IntegrationProcessID, IntegrationAdapterType) {
    var url = GetSiteRootURL() + '/Views/Admin/IntegrationProcesses/IntegrationAdapterView.aspx?IntegrationAdapterID=' + IntegrationAdapterID + '&IntegrationAdapterType=' + IntegrationAdapterType + '&UIMode=' + UIMode + '&IntegrationProcessID=' + IntegrationProcessID;
    ShowWindowRegular('Integration Adapter', 'windowIntegrationAdapter', url, 1000, 600, null);
}

function ShowIntegrationProcessMappingView(IntegrationProcessID, UIMode) {
    var url = GetSiteRootURL() + '/Views/Admin/IntegrationProcesses/IntegrationProcessMappingView.aspx?IntegrationProcessID=' + IntegrationProcessID + '&UIMode=' + UIMode;
    ShowWindowRegular('Integration Process Mapping', 'windowIntegrationProcessMapping', url, 1000, 600, null);
}

function ShowIntegrationTransactionDetails(IntegrationTransactionID, UIMode) {
    var url = GetSiteRootURL() + '/Views/Tools/IntegrationTransactionDetailsView.aspx?IntegrationTransactionID=' + IntegrationTransactionID + '&UIMode=' + UIMode;
    ShowWindowRegular('Integration Transaction Details', 'windowIntegrationTransactionDetailsView', url, 1100, 600, null);
}

function ShowIntegrationApdaterQueryView(IntegrationAdapterQueryID, UIMode, IntegrationAdapterID, IntegrationProcessID) {
    var url = GetSiteRootURL() + '/Views/Admin/IntegrationProcesses/IntegrationAdapterQueryView.aspx?IntegrationAdapterQueryID=' + IntegrationAdapterQueryID + '&UIMode=' + UIMode + '&IntegrationAdapterID=' + IntegrationAdapterID + '&IntegrationProcessID=' + IntegrationProcessID;
    ShowWindowRegular('Integration Adapter Query', 'windowIntegrationAdapterQueryView', url, 1000, 600, null);
}