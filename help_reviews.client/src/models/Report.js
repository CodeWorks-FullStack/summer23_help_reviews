

export class Report {
  constructor(data) {
    this.id = data.id
    this.body = data.body
    this.title = data.title
    this.restaurantId = data.restaurantId
    this.creatorId = data.creatorId
    this.creator = data.creator
    // NOTE do the date modifying stuff here maybe if you aren't planning on using this in multiple components 
    this.createdAt = new Date(data.createdAt).toLocaleDateString('en-us')
  }
}

// let object = {
//   "title": "I'm allergic to cats",
//   "body": "Why did I even go here????? 0 stars out of 5",
//   "restaurantId": 3,
//   "creatorId": "64ad7dd487ee9a53a0226331",
//   "creator": {
//     "name": "jerms",
//     "picture": "https://plus.unsplash.com/premium_photo-1661892259737-2d658fcf7ebb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80",
//     "id": "64ad7dd487ee9a53a0226331",
//     "createdAt": "2023-08-22T18:48:01",
//     "updatedAt": "2023-08-23T17:48:04"
//   },
//   "id": 2,
//   "createdAt": "2023-08-24T16:43:43",
//   "updatedAt": "2023-08-24T16:43:43"
// }