/// <binding BeforeBuild='less' AfterBuild='less' Clean='less' ProjectOpened='less' />
var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('Styles/*.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});