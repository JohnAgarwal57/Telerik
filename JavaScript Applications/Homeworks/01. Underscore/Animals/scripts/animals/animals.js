define(['./animal'],function (Animal) {
	'use strict';
	var Animals = (function() {
		function Animals() {
			this._animals = [];
		}

		Animals.prototype.addAnimal = function(animal) {
			if (animal instanceof Animal) {
				this._animals.push(animal);
			}
		};

		Animals.prototype.listAnimals = function() {
			var animals = this._animals;
			return animals;
		};

		Animals.prototype.setStudents = function(animals) {
			if (validateData(animals, "object")) {
				this._animals = animals;
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

		return Animals;
	}());

	return Animals;
});