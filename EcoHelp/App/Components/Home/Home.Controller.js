// Creation of the Home Controller
app.controller("Home", Home);

// Injecting modules the controller is dependant of
Home.$inject = ["$scope", "HomeService"];

function Home($scope, HomeService) {
    $scope.CurrentUser = {};
    $scope.FallBackPicture = path + "Resources/images/circle_person.png";

    $scope.Categories = [];

    function Init() {
        $scope.CurrentUser.FullName = "Victor De Velasco";

        var promise = HomeService.GetCategories();

        promise.then
        (
            function (response) {
                $scope.Categories = response.data;
            }
        )
        .catch
        (
            function (response) {
                alert('SOMETHING WENT WRONG!')
            }
        );
    }

    Init();
}