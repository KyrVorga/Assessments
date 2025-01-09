const mongoose = require('mongoose');
const { Schema } = mongoose;

const invitationSchema = new Schema({
    code: { type: String, length: 10 },
    status: { type: String, enum: ['active', 'expired'] },
    maxUses: Number,
    currentUses: Number,
    expiryDate: Date,
    group: { type: Schema.Types.ObjectId, ref: 'Group' }
});
  

module.exports = mongoose.model('Invitation', invitationSchema);