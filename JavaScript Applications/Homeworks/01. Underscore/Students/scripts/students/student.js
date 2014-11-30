define(function() {
	'use strict';
	var Student = (function() {
		function Student(firstName, lastName, age, mark) {
			if (validateData(firstName, "string")) {
				this._firstName = firstName;
			}
			
			if (validateData(lastName, "string")) {
				this._lastName = lastName;
			}

			if (validateData(age, "number")) {
				this._age = age;
			}

			if (validateData(mark, "number")) {
				this._mark = mark;
			}
		}

		Student.prototype.getFirstName = function () {
			var firstName = this._firstName;
			return firstName;
		};

		Student.prototype.getLastName = function () {
			var lastName = this._lastName;
			return lastName;
		};

		Student.prototype.getAge = function () {
			var age = this._age;
			return age;
		};

		Student.prototype.getMark = function () {
			var mark = this._mark;
			return mark;
		};

		function validateData(item, type) {
			if (typeof item === type || isFinite(item)) {
				return true;
			}
			else {
				throw new Error(item + " must be a " + type + " variable");
			}
		}
	
		return Student;
	})();

	return Student;
});