var mongoose = require('mongoose'),
	Schema = mongoose.Schema,
	commentSchema = mongoose.Schema({
		user : {
			type: Schema.ObjectId,
			ref: 'User'
		},
		comment: String
	}),
	Comment = mongoose.model('Comment', commentSchema);