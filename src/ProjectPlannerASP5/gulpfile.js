var gulp = require("gulp"),
    rimraf = require("rimraf"),
    fx = require("fs"),
    less = require("gulp-less");

var project = require("./project.json");

gulp.task("less", function () {
    gulp.src(project.webroot + "/less/main.less")
            .pipe(less())
            .pipe(gulp.dest(project.webroot + "/css"));
});