// Eco Application Module Creation
// @module EcoApp

// Create the main module
var app =
    angular.module
    (
        "EcoApp",

        // Dependency Injection of additional modules
        [
            "ngSanitize",
            "ngAnimate"
        ]
    );