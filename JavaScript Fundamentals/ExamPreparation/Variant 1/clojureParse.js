function solve(args) {
	var lines = args.map(function(item) {
			item = item.trim();
			if (item.indexOf('def') === -1) {
				return item;
			}

			item = item.substr(item.indexOf('def') + 3).trim();
			item = item.substr(0, item.length - 1).trim();
			return item;
		}),
		operations = [{}],
		separator;

	for (var i = 0; i < lines.length; i++) {
		if (lines[i].indexOf('(') === -1) {
			separator  = lines[i].indexOf(' ');
		} else {
			separator = lines[i].indexOf('(');
		}
		var first = lines[i].substr(0, separator).trim();
			second = lines[i].substr(separator + 1).trim();

		if (lines[i].indexOf(')') !== -1) {
			second = second.substring(0, second.length - 1).trim();
		}
		
		operations[i] = {func : first, value : second};
	}

	var parsedOperations = [];

	for (i = 0; i < operations.length; i++) {
		var operation = operations[i],
			items = [],
			current = '';
				
		for (var j = 0; j < operation.value.length; j++) {
			if (operation.value[j] !== ' ') {
				current = current + operation.value[j];
			} else {
				if (current !== '') {
					items.push(current);
				}
				current = '';
			}
		}

		if (current !== '') {
			items.push(current);
		}

		parsedOperations.push(items);
	}

	var calculated = [];
	for (i = 0; i < operations.length; i++) {
		switch(operations[i].value[0]) {
			case '*' :
					break;
			case '/' :
					break;
			case '+' :
					break;
			case '-' :
					break;
			default : calculated[operations[i].func] = operations[i].value;
		}
	}
	console.log(calculated);
}

var test1 = [
	'  ( def   func   10)',
	'            (  def    newFunc   (  +  func   2   ))',
	'(def   sumFunc   (  +   func    func    newFunc   0   0 0))',
	'(   *   sumFunc   2)'
];

solve(test1);