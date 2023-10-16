
var setting = {
    GetAll: function () {
        Helper.AjaxCallGet("https://localhost:7215/api/Settings", {}, "json",
            function (data) {
                console.log(data)
                $("#facelink").attr("href", data.facebookLink);
                $("#twitlink").attr("href", data.twiterLink);
                $("#instalink").attr("href", data.instagramLink);
                $("#googlelink").attr("href", data.linkedinLink);
                $("#githuplink").attr("href", data.githupLink);
               
            }, function () { }
        );
    }
}


setting.GetAll();