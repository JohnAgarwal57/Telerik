var mongoose = require('mongoose'),
	messageSchema = mongoose.Schema({
		from: {
			type: mongoose.Schema.ObjectId,
			ref: 'User',
			required: true
		},
		to: {
			type: mongoose.Schema.ObjectId,
			ref: 'User',
			required: true
		},
		text: {
			type: String,
			required: true
		}
	}),
	Message = mongoose.model('Message', messageSchema);