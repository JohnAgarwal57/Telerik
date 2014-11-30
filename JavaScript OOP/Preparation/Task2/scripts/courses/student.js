define(function() {
	'use strict';
	var Student;
	Student = (function() {
		function Student(student) {
			this.name = student.name;
			this.exam = student.exam;
			this.homework = student.homework;
			this.attendance = student.attendance;
			this.teamwork = student.teamwork;
			this.bonus = student.bonus;
		}
	
		return Student;
	})();

	return Student;
});