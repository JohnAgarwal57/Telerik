define(function () {
	'use strict';
	var Course;
	Course = (function() {
		function Course(title, formula) {
			this.title = title;
			this._students = [];
			this._formula = formula;
		}

		Course.prototype.addStudent = function(student) {
			var totalScore = this._formula(student);

			this._students.push({
				student: student,
				totalScore: totalScore
			});
		};

		Course.prototype.calculateResults = function() {
			var students = this._students;

			for (var i = 0, len = students.length; i < len; i++) {
				console.log(students[i].student.name + " " + students[i].totalScore);
			}
		};

		Course.prototype.getTopStudentsByExam = function(count) {
			var sortedStudents = this._students.sort(examCompare);

			console.log("Top " + count + " students by exam:");
			
			for (var i = 0; i < count; i++) {
				console.log(sortedStudents[i].student.name + " " + sortedStudents[i].student.exam);
			}
		};

		Course.prototype.getTopStudentsByTotalScore = function(count) {
			var sortedStudents = this._students.sort(totalScoreCompare);

			console.log("Top " + count + " students by total score:");

			for (var i = 0; i < count; i++) {
				console.log(sortedStudents[i].student.name + " " + sortedStudents[i].totalScore);
			}
		};

		function examCompare(a, b) {
			return b.student.exam - a.student.exam;
		}

		function totalScoreCompare(a,b) {
			return b.totalScore - a.totalScore;
		}

		return Course;
	}());

	return Course;
});