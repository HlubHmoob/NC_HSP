var gulp = require('gulp'),
    sass = require('gulp-sass'),
    minifyCSS = require('gulp-minify-css');

gulp.task('sass', function () {
    return gulp.src('./Content/scss/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./Content/css'));
});

gulp.task('watch', function () {
    gulp.watch('./Content/scss/*.scss', ['sass']);
});

gulp.task('minify-css', function () {
    return gulp.src('./assets/css/style.css')
        .pipe(minifyCSS({ keepSpecialComments: 1 }))
        .pipe(gulp.dest('./assets/minify-css'));
});

gulp.task('default', ['sass', 'minify-css', 'watch']);