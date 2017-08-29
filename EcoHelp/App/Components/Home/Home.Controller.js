// Creation of the Home Controller
app.controller("Home", Home);

// Injecting modules the controller is dependant of
Home.$inject = ["$scope", "HomeService"];

function Home($scope, HomeService) {
    $scope.CurrentUser = {};
    $scope.FallBackPicture = path + "Resources/images/circle_person.png";

    $scope.SelectedIssue = {};

    $scope.Categories = [];
    $scope.Supervisors = [];
    $scope.SupportTechnicians = [];
    $scope.Developers = [];
    $scope.Causes = [];

    $scope.LoadCauses = LoadCauses;

    function Init() {
        $scope.CurrentUser.FullName = "Victor De Velasco";

        var promise = HomeService.GetPageData();

        promise.then
        (
            function (response) {
                $scope.Categories = response.data.Categories;
                $scope.Supervisors = response.data.Supervisors;
                $scope.SupportTechnicians = response.data.SupportTechnicians;
                $scope.Developers = response.data.Developers;
            }
        )
        .catch
        (
            function (response) {
                alert("SOMETHING WENT WRONG!")
            }
        );
    }

    function LoadCauses(issue) {
        if (issue !== undefined && issue !== null) {
            $scope.SelectedIssue = issue;

            if (issue.Causes === undefined || issue.Causes === null)
            {
                GetCausesByIssueId(issue);
            }

            else
            {
                $scope.Causes = issue.Causes;
            }
        }
    }

    function GetCausesByIssueId(issue) {
        if (issue !== undefined && issue !== null) {

            var promise = HomeService.GetCausesByIssueId(issue.Id);

            promise.then
            (
                function (response) {
                    var selectedIssue = $scope.SelectedIssue;
                    selectedIssue.Causes = response.data;

                    LoadCauses(selectedIssue);
                }
            )
            .catch
            (
                function (response) {
                    alert("SOMETHING WENT WRONG!")
                }
            );
        }
    }

    Init();
}