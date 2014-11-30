function solve(args) {
	var dimensions = args[0].split(' '),
		rows = dimensions[0],
		cols = dimensions[1],
		matrix = args.slice(1),
		row = rows - 1,
		col = cols -1,
		move = matrix[row][col],
		sum = 0,
		count = 0,
		sumMatrix = [];

	for (var i = 0; i < rows; i++) {
		sumMatrix[i] = [];
		for (var j = 0; j < cols; j++) {
			sumMatrix[i].push(Math.pow(2, i) - j);
		}
	}

	matrix[row][col] = 'X';
	sum = parseInt(sum + sumMatrix[row][col], 10);

	while(true) {
		if (sumMatrix[row][col] === 'X') {
			return 'Sadly the horse is doomed in ' + count + ' jumps';
		}

		sumMatrix[row][col] = 'X';
	
		if (move == 1) {
			row += -2;
			col += 1;
		} else if(move == 2) {
			row += -1;
			col += 2;
		} else if(move == 3) {
			row += 1;
			col += 2;
		} else if(move == 4) {
			row += 2;
			col += 1;
		} else if(move == 5) {
			row+= 2;
			col+= -1;
		} else if(move == 6) {
			row += 1;
			col += -2;
		} else if(move == 7) {
			row += -1;
			col += -2;
		} else if(move == 8) {
			row += -2;
			col += -1;
		}

		if (row < 0 || row >= rows || col < 0 || col>=cols) {
			return 'Go go Horsy! Collected ' + sum + ' weeds';
		}

		move = matrix[row][col];
		sum = parseInt(sum + sumMatrix[row][col], 10);
		count++;
	}
}

test1 = [
  '3 5',
  '54361',
  '43326',
  '52188',
];

test2 = [
  '3 5',
  '54561',
  '43328',
  '52388',
];



solve(test2);