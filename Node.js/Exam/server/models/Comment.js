var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var commentSchema = mongoose.Schema({
    user : { type: Schema.ObjectId, ref: 'User' },
    comment: String
});

var Comment = mongoose.model('Comment', commentSchema);
