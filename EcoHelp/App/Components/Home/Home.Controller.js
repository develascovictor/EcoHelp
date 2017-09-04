// Creation of the Home Controller
app.controller("Home", Home);

// Injecting modules the controller is dependant of
Home.$inject = ["$scope", "HomeService"];

function Home($scope, HomeService) {
    $scope.CurrentUser = {};
    $scope.FallBackPicture = path + "Resources/images/circle_person.png";

    $scope.SelectedIssue = {};

    $scope.ContactSections = [];
    $scope.Categories = [];
    $scope.Causes = [];

    $scope.LoadCauses = LoadCauses;

    function Init() {
        var promise = HomeService.GetPageData();

        promise.then
        (
            function (response) {
                var supervisorContact;
                var currentUser = response.data.CurrentUser;
                var supervisors = response.data.Supervisors;
                var supportTechnicians = response.data.SupportTechnicians;
                var developers = response.data.Developers;
                $scope.CurrentUser = currentUser;
                $scope.Categories = response.data.Categories;

                switch (currentUser.Role.Id) {
                    //Supervisor
                    case 3:
                        {
                            supervisorContact = currentUser.Contact;
                            break;
                        }

                    //Station
                    case 4:
                        {
                            supervisorContact = currentUser.AllowedStations[0].SupervisorContact;
                            break;
                        }
                }

                var contactId = (supervisorContact !== undefined && supervisorContact !== null) ? supervisorContact.Id : 0;

                $scope.ContactSections.push(GetContactSection("Supervisor", [supervisorContact]));
                $scope.ContactSections.push(GetContactSection("Supervisores de Zona", Enumerable.From(supervisors).Where(function (x) { return x.Id !== contactId; }).ToArray()));
                $scope.ContactSections.push(GetContactSection("Soporte Técnico", supportTechnicians));
                $scope.ContactSections.push(GetContactSection("Desarrollo", developers));

                setTimeout(SetContactInfoHeight, 1);
            }
        )
        .catch
        (
            function (response) {
                alert("SOMETHING WENT WRONG!")
            }
        );
    }

    function GetContactSection(title, contacts) {
        var contactSection =
            {
                Title: title,
                Contacts: contacts
            };
        return contactSection;
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

    function SetContactInfoHeight() {
        var height = 0;
        var highest = 0;
        var columns = $(".contact-info").children();

        columns.each(function () {
            height = $(this).height();
            highest = height > highest ? height : highest;
        });

        columns.css("height", highest);
    }

    Init();
}