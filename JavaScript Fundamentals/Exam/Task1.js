function solve(args) {
	var leva = parseInt(args[0], 10),
		firstCakePrice = parseInt(args[1], 10),
		secondCakePrice = parseInt(args[2], 10),
		thirdCakePrice = parseInt(args[3], 10),
		maxLeva = parseInt(0, 10);

	for (var i = 0; i <= leva/firstCakePrice; i++) {
		for (var j = 0; j < leva/secondCakePrice; j++) {
			for (var k = 0; k < leva/thirdCakePrice; k++) {
				var sum = i * firstCakePrice + j * secondCakePrice + k * thirdCakePrice,
					currentSum = parseInt(sum, 10);

				if ((currentSum > maxLeva) && currentSum <= leva) {
					maxLeva = currentSum;
				}
			}
		}
	}
	return maxLeva;
}

test1 = [
	'110',
	'13',
	'15',
	'17',
];


test2 = [
'20',
'11',
'200',
'300',

];

console.log(solve(test2));