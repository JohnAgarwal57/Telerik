function createCalendar(selector, events) {
	var currentSelector = selector.replace(/(^#)|(,$)/g, ''),
		width = 1020,
		height = 700,
		currentSelect = document.getElementById(currentSelector),
		newDiv = document.createElement('div'),
		weekday = new Array(7),
		offset = 21,
		upDivHeight = 20,
		downDivHeight = 90;

	weekday[0]=  'Sun';
	weekday[1] = 'Mon';
	weekday[2] = 'Tue';
	weekday[3] = 'Wed';
	weekday[4] = 'Thu';
	weekday[5] = 'Fri';
	weekday[6] = 'Sat';

	for (var i = 0; i < 30; i++) {
		var left = Math.round(i % 7) * 141 + 10,
			top = Math.floor(i/7) * 112 + 80,
			divWidth = 140,
			date = new Date(2014, 5, i+1),
			dateText = weekday[date.getDay()] + ' ' + (i+1) + ' June 2014',
			eventText = '';
		
		for (var j = 0, len = events.length; j < len; j++) {
			if(events[j].date == i+1) {
				eventText = events[j].hour + ' ' + events[j].title;
			}
		}

		createRandomDiv(currentSelect, left, top, divWidth, upDivHeight, dateText, 'center', '#CCC', 'titles');

		top = top + offset;
		createRandomDiv(currentSelect, left, top, divWidth, downDivHeight, eventText, 'left', '#fff', 'events');
		eventText = '';
	}
}

function createRandomDiv(selector, left, top, width, height, text, align, color, classN){
	var div = document.createElement('div');

	div.style.position = 'absolute';

	div.style.width = width + 'px';
	div.style.height = height + 'px';
	div.style.left = left + 'px';
	div.style.top = top + 'px';
	div.style.border = '1px solid black';
	div.style.textAlign = align;
	div.style.backgroundColor = color;
	div.classList.add(classN);

	if (classN == 'titles') {
		div.addEventListener('mouseover', onMouseOver, false);
		div.addEventListener('mouseout', onMouseOut, false);
		div.addEventListener('click', onMouseClick, false);
	}

	div.appendChild(createStrong(text));
	selector.appendChild(div);
}

function createStrong(text) {
	var strong = document.createElement('strong');
	strong.innerText = text;
	return strong;
}

function onMouseOver () {
	if (this.id !== 'selected') {
		this.style.backgroundColor = '#999';
	}
}

function onMouseOut () {
	if (this.id !== 'selected') {
		this.style.backgroundColor = '#CCC';
	}
}

function onMouseClick () {
	if (document.getElementById('selected')) {
		var selected = document.getElementById('selected');
		selected.id = '';
		selected.style.backgroundColor = '#CCC';
	}

	this.id = 'selected';
	this.style.backgroundColor = '#FFF';
}