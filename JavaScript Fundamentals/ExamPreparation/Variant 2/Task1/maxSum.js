function solve(args) {
	var numbers = args.slice(1).map(Number),
		sum = numbers[0],
		currentSum = numbers[0];

	for (var i = 1; i < numbers.length; i++) {
		if (numbers[i] + currentSum >= numbers[i]) {
			currentSum = numbers[i] + currentSum;
		} else {
			currentSum = numbers[i];
		}

		if (currentSum > sum) {
			sum = currentSum;
		}
	}

	return(sum);
}

var test1 = [
	'8',
	'1', '6', '-9', '4', '4', '-2', '10', '-1',
];

var test2 = [
	'6',
	'1', '3', '-5', '8', '7', '-6'
];

var test3 = [
	'9',
	'-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6',
];

console.log(solve(test1));
console.log(solve(test2));
console.log(solve(test3));