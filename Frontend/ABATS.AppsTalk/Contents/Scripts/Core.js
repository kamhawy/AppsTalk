/*--------------------*/
/*   Core Utilities   */
/*--------------------*/

var CoreUtilities = {
    GetSiteRootURL: function () {
        return document.location.protocol + '//' + document.location.hostname + '/ABATS.AppsTalk';
    },

    BuildPageFullURL: function (url, queryStringItems) {
        var fullURL = CoreUtilities.GetSiteRootURL() + url;
        if (queryStringItems && queryStringItems.length > 0) {
            for (var i = 0; i < queryStringItems.length; i++) {
                if (queryStringItems[i].key && queryStringItems[i].value) {
                    if (i == 0) {
                        fullURL += "?";
                    } else {
                        fullURL += "&";
                    }
                    fullURL += queryStringItems[i].key + "=" + queryStringItems[i].value;
                }
            }
        }
        return fullURL;
    }
};

/*------------------*/
/*   UI Utilities   */
/*------------------*/

var UIUtilities = {

    AddCssClass: function (className, element) {
        if (element.className.indexOf(className) < 0) {
            element.className = element.className + " " + className;
        }
    },

    RemoveCssClass: function (className, element) {
        element.className = element.className.replace(className, "").replace(/^\s+/, '').replace(/\s+$/, '');
    },

    RenderMenu: function () {
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
};

/*----------------------*/
/*   Window Utilities   */
/*----------------------*/

var WindowUtilities = {

    OpenWindowInSameTab: function (url, onunload, extraFeatures) {
        var features = 'resizable=1,scrollbars=1,statusbar=1';
        if (extraFeatures) {
            features += ',' + extraFeatures;
        }
        var newWindow = window.open(url, '_self', features);
        if (onunload) {
            newWindow.onunload = onunload;
        }
        if (window.focus) {
            newWindow.focus();
        }
    },

    OpenWindowInPopup: function (windowName, url, width, height, onunload, extraFeatures) {
        var features = 'height=' + height + ',width=' + width + ',resizable=1,scrollbars=1,statusbar=1';
        if (extraFeatures) {
            features += ',' + extraFeatures;
        }
        var newWindow = window.open(url, windowName, features);
        if (onunload) {
            newWindow.onunload = onunload;
        }
        if (window.focus) {
            newWindow.focus();
        }
    },

    OnWindowLoad: function (sender, args) {
        theForm.onkeypress = function (e) {
            e = e || window.event;
            if (e.keyCode == 13) {
                if (e.preventDefault) e.preventDefault();
                if (e.stopPropagation) e.stopPropagation();
                e.cancelBubble = false;
                return false;
            }
        }
    },

    // System Windows

    ShowApplicationDatabaseView: function (ApplicationDatabaseID, ApplicationID, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Admin/Applications/ApplicationDatabaseView.aspx', [
            { key: "ApplicationDatabaseID", value: ApplicationDatabaseID },
            { key: "ApplicationID", value: ApplicationID },
            { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInSameTab(pagefullURL);
    },

    ShowApplicationWebServiceView: function (ApplicationWebServiceID, ApplicationID, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Admin/Applications/ApplicationWebServiceView.aspx', [
                { key: "ApplicationWebServiceID", value: ApplicationWebServiceID },
                { key: "ApplicationID", value: ApplicationID },
                { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInSameTab(pagefullURL);
    },

    ShowApplicationDatabaseQueryView: function (ApplicationDatabaseQueryID, ApplicationDatabaseID, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Admin/Applications/ApplicationDatabaseQueryView.aspx', [
                { key: "ApplicationDatabaseQueryID", value: ApplicationDatabaseQueryID },
                { key: "ApplicationDatabaseID", value: ApplicationDatabaseID },
                { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInSameTab(pagefullURL);
    },

    ShowApplicationWebServiceRequestView: function (ApplicationWebServiceRequestID, ApplicationWebServiceID, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Admin/Applications/ApplicationWebServiceRequestView.aspx', [
                { key: "ApplicationWebServiceRequestID", value: ApplicationWebServiceRequestID },
                { key: "ApplicationWebServiceID", value: ApplicationWebServiceID },
                { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInSameTab(pagefullURL);
    },

    ShowIntegrationProcessMappingView: function (IntegrationProcessID, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Admin/IntegrationProcesses/IntegrationProcessMappingView.aspx', [
            { key: "IntegrationProcessID", value: IntegrationProcessID },
            { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInSameTab(pagefullURL);
    },

    ShowIntegrationAdapterView: function (IntegrationAdapterID, IntegrationProcessID, IntegrationAdapterType, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Admin/IntegrationProcesses/IntegrationAdapterView.aspx', [
                { key: "IntegrationAdapterID", value: IntegrationAdapterID },
                { key: "IntegrationProcessID", value: IntegrationProcessID },
                { key: "IntegrationAdapterType", value: IntegrationAdapterType },
                { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInSameTab(pagefullURL);
    },

    ShowIntegrationTransactionDetails: function (IntegrationTransactionID, UIMode) {
        var pagefullURL = CoreUtilities.BuildPageFullURL('/Views/Tools/IntegrationTransactionDetailsView.aspx', [
            { key: "IntegrationTransactionID", value: IntegrationTransactionID },
            { key: "UIMode", value: UIMode }
        ]);
        WindowUtilities.OpenWindowInPopup('IntegrationTransactionDetailsView', pagefullURL, 800, 600);
    }
};