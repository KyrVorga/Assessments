const mongoose = require('mongoose');
const { Schema } = mongoose;

const groupSchema = new Schema({
    name: String,
    users: [{ type: Schema.Types.ObjectId, ref: 'User' }],
    invitations: [{ type: Schema.Types.ObjectId, ref: 'Invitation' }]
});

module.exports = mongoose.model('Group', groupSchema);