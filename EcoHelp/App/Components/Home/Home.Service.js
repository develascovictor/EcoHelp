app.factory("HomeService", HomeService);
HomeService.$inject = ["$http"];

function HomeService($http) {
    // Update path which is obtained from Index
    var homePath = "Home/";

    return {
        GetCategories: GetCategories,
        GetCausesByIssueId: GetCausesByIssueId
    }

    function GetCategories() {
        return $http
        (
            {
                url: path + homePath + "GetCategories",
                method: "GET",
                headers:
                {
                    "Content-Type": "application/json"
                }
            }
        );
    }

    function GetCausesByIssueId(issueId) {
        return $http
        (
            {
                url: path + homePath + "GetCausesByIssueId",
                method: "POST",
                headers:
                {
                    "Content-Type": "application/json"
                },
                data:
                {
                    issueId: issueId
                }
            }
        );
    }
}