var gulp = require('gulp');
var less = require('gulp-less');
var watch = require('gulp-watch');

gulp.task('css', function() {
	gulp.src('maze.less')
		.pipe(less())
		.pipe(gulp.dest(''));
});

gulp.task('default', ['css', 'watch']);

gulp.task('watch', function() {
	gulp.watch('**/*', ['css']);
});