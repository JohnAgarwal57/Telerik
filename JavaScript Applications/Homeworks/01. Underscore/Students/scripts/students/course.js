define(['./student'],function (Student) {
	'use strict';
	var Course = (function() {
		function Course(name) {
			if (validateData(name, "string") && (6 < name.length && name.length < 40)) {
				this._name = name;
			}
			else {
				throw new Error('Name must be between 6 and 30 characters');
			}

			this._students = [];
		}

		Course.prototype.addStudent = function(student) {
			if (student instanceof Student) {
				this._students.push(student);
			}
		};

		Course.prototype.listStudents = function() {
			var students = this._students;
			return students;
		};

		Course.prototype.setStudents = function(students) {
			if (validateData(students, "object")) {
				this._students = students;
			}
		};

		function validateData(item, type) {
			if (typeof item === type) {
				return true;
			}
			else {
				throw new Error(item + " must be a " + type + " variable");
			}
		}

		return Course;
	}());

	return Course;
});