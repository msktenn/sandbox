import React, { Component } from "react";
import { connect } from "react-redux";
import { fetchPosts } from "../actions/postActions";

class Posts extends Component {
  constructor() {
    console.log("constructor1");
    super();
  }

  // static getDerivedStateFromProps() {
  //   console.log("getdirevedstate");
  //   this.props.fetchPosts();
  // }

  render() {
    console.log("render");
    const postItems = this.props.posts.map(post => (
      <div key={post.id}>
        <h3>{post.title}</h3>
        <p>{post.body}</p>
      </div>
    ));
    return (
      <div>
        <h1>Posts</h1>
        {postItems}
      </div>
    );
  }

  componentDidMount() {
    console.log("componentDidMount");
  }

  componentWillMount() {
    this.props.fetchPosts();
    console.log("compoenentWillMount");
  }

  // shouldComponentUpdate() {
  //   console.log("shouldComponentUpdate");
  // }

  // getSnapshotBeforeUpdate() {
  //   console.log("getSnapshotBeforeUpdate");
  // }

  // componentDidUpdate() {
  //   console.log("componentDidUpdate");
  // }

  // componentWillUpdate() {
  //   console.log("componentWilUpdate");
  // }

  // componentWillReceiveProps() {
  //   console.log("componentWillRecieveProps");
  // }

  // componentWillUnmount() {
  //   console.log("componentWillUnmount");
  // }

  // static getDerivedStateFromError() {
  //   console.log("getDerivedStateFromError");
  // }

  // compoentDidCatch() {
  //   console.log("componentDidCatch");
  // }

  // setState()
  // {
  //   super.setState()
  // }
}

const mapStateToProps = state => ({
  posts: state.posts.items
})

export default connect(
  mapStateToProps,
  { fetchPosts }
)(Posts);
