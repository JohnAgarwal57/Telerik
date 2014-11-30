(function () {
	function createJsConsole(selector) {
		var _this = this,
			consoleElement = document.querySelector(selector),
			textArea = document.createElement("p");

		if (consoleElement.className) {
			consoleElement.className = consoleElement.className + ' js-console';
		}
		else {
			consoleElement.className = "js-console";
		}

		consoleElement.appendChild(textArea);

		_this.write = function jsConsoleWrite(text) {
			var textLine = document.createElement('span');
			textLine.innerHTML = text;
			textArea.appendChild(textLine);
			consoleElement.scrollTop = consoleElement.scrollHeight;
		};

		_this.writeLine = function jsConsoleWriteLine(text) {
			_this.write(text);
			textArea.appendChild(document.createElement('br'));
		};

		_this.read = function readText(inputSelector) {
			var element = document.querySelector(inputSelector);
			if (element.innerHTML) {
				return element.innerHTML;
			}
			else {
				return element.value;
			}
		};

		_this.readInteger = function readInteger(inputSelector) {
			var text = _this.read(inputSelector);
			return parseInt(text, 10);
		};

		_this.readFloat = function readFloat(inputSelector) {
			var text = _this.read(inputSelector);
			return parseFloat(text);
		};

		return _this;
	}
	jsConsole = new createJsConsole('#js-console');
}).call(this);
