//Routing Configuration
app.config
(
    [
        "$httpProvider",

        function ($httpProvider)
        {
            $httpProvider.defaults.headers.post = {};
            $httpProvider.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";

            //initialize get if not there
            if (!$httpProvider.defaults.headers.get)
            {
                $httpProvider.defaults.headers.get = {};
            }

            //disable IE ajax request caching
            $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache, no-store, must-revalidate';
            $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
            $httpProvider.defaults.headers.get['Expires'] = '0';
        }
    ]
);