function z(n){
	function a(n){
		return (n === 0) ? 1 : (4 * n - 2) * a(n - 1) / (n + 1);
	}
	
	return a(n)/2;
}

console.log(z(7));