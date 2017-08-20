// Creation of the Home Controller
app.controller("Home", Home);

// Injecting modules the controller is dependant of
Home.$inject = ["$scope"];

function Home($scope) {
    $scope.CurrentUser = {};
    $scope.FallBackPicture = path + "Resources/images/circle_person.png";

    function Init() {
        $scope.CurrentUser.FullName = "Victor De Velasco";
    }

    Init();
}