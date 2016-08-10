fs = require('fs');

var inputFilePath = process.argv[2];
var outputFilePath = process.argv[3];
var encoding = process.argv[4] || 'utf8';

fs.readFile(inputFilePath, encoding, function(err, data) {
	if (err) return console.log(err);
	var currencies = JSON.parse(data);
	currencies = Object.keys(currencies).map(function(code) {
		return currencies[code];
	});
	currencies = currencies.map(function(currency) {
		return {
			Symbol: currency.symbol,
			Name: currency.name,
			SymbolNative: currency.symbol_native,
			DecimalDigits: currency.decimal_digits,
			Code: currency.code,
			NamePlural: currency.name_plural,
		};
	});
	data = JSON.stringify(currencies, null, '\t');
	fs.writeFile(outputFilePath, data, encoding, function(err, data) {
		if (err) return console.log(err);
	});
});