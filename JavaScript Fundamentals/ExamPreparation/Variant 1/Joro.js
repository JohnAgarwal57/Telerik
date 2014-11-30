function solve(args) {
	var firstLine = args[0].split(' '),
		startPosition = args[1].split(' '),
		rows = firstLine[0],
		cols = firstLine[1],
		numberOfjumps = firstLine[2],
		row = parseInt(startPosition[0], 10),
		col = parseInt(startPosition[1], 10),
		moves = args.slice(2),
		matrix = [],
		counter = 1,
		numberOfMoves = 0,
		countNumbers = 0;

	for (var i = 0; i < rows; i++) {
		matrix[i] = [];
		for (var j = 0; j < cols; j++) {
			matrix[i][j] = counter;
			counter++;
		}
	}

	countNumbers = matrix[row][col];

	while(true) {
		for (i = 0; i < moves.length; i++) {
			var currentMove = moves[i].split(' '),
				newRows = parseInt(currentMove[0], 10),
				newCols = parseInt(currentMove[1], 10);

			row = row + newRows;
			col = col + newCols;

			if (row < 0 || row >= rows || col < 0 || col>=cols) {
				return 'escaped ' + countNumbers;
			}

			if (matrix[row][col] === 'X') {
				return 'caught ' + numberOfMoves;
			}

			numberOfMoves++;
			countNumbers += matrix[row][col];
		}
	}
}

var test1 = [
'6 7 3',
'0 0',
'2 2',
'-2 2',
'3 -1',
];

solve(test1);