
var app = angular.module('app', []);
var url = 'api/NewsFeeds/';
app.factory('newsFeedFactory', function ($http) {
    return {
        getNewsFeed: function () {
            return $http.get(url);
        },
        addNewsFeed: function (newsFeed) {
            return $http.post(url, newsFeed);
        },
        deleteNewsFeed: function (newsFeed) {
            return $http.delete(url + newsFeed.newsFeedID);
        },
        updateNewsFeed: function (newsFeed) {
            return $http.put(url + newsFeed.Id, newsFeed);
        }
    };
});

app.controller('NewsFeedsController', ['$scope', 'newsFeedFactory', function ($scope, newsFeedFactory) {
    $scope.newsFeeds = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.newsFeed.editMode = !this.newsFeed.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save newsFeed Event
    $scope.save = function () {
        $scope.loading = true;
        var newsfeed = this.newsFeed;
        newsFeedFactory.updateNewsFeed(newsfeed).success(function (data) {
            alert("Saved Successfully!!");
            newsfeed.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving newsFeed! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    // add newsFeed Event
    $scope.add = function () {
        $scope.loading = true;
        newsFeedFactory.addNewsFeed(this.newNewsFeed).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.newsFeeds.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding newsFeed! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete newsFeed Event
    $scope.delnewsFeed = function () {
        $scope.loading = true;
        var currentNewsFeed = this.newsFeed;
        newsFeedFactory.deleteNewsFeed(currentNewsFeed).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.newsFeeds, function (i) {
                if ($scope.newsFeeds[i].newsFeedID === currentNewsFeed.newsFeedID) {
                    $scope.newsFeeds.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving NewsFeed! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    //get all NewsFeeds- Self Calling -On load
    newsFeedFactory.getNewsFeed().success(function (data) {
        $scope.newsFeeds = data;
        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading posts! " + data.ExceptionMessage;
        $scope.loading = false;
    });

}]);