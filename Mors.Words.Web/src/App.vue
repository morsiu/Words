<script setup>
import * as api from "./api"
import { ref } from 'vue'

const pronunciation = ref(false);
const meaning = ref(false);
const word = ref('')
const trackedWords = ref([]);

refreshTrackedWords();

async function hideWord(word, meaning) {
  if (await api.hideWord({ word, meaning })) {
    await refreshTrackedWords();
  }
}

async function trackWord(newWord, meaning, pronunciation) {
  if (await api.trackWord({ word: newWord, pronunciation, meaning })) {
    word.value = "";
    await refreshTrackedWords();
  }
}

async function refreshTrackedWords() {
  const newTrackedWords = await api.trackedWords();
  trackedWords.value = newTrackedWords;
}
</script>

<template>
  <div class="container">
    <div class="row">
      <div class="col">
        <h1>Words</h1>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <input v-model="word" class="form-control" placeholder="Enter a word" type="text" />
      </div>
      <div class="col col-1">
        <button class="btn btn-primary" @click="trackWord(word, meaning, pronunciation)">Add</button>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="form-check">
          <input id="pronunciation-input" class="form-check-input" v-model="pronunciation" type="checkbox" />
          <label for="pronunciation-input" class="form-check-label">Pronunciation</label>
        </div>
        <div class="form-check">
          <input id="meaning-input" class="form-check-input" v-model="meaning" type="checkbox" />
          <label for="meaning-input" class="form-check-label">Meaning</label>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <table class="table">
          <thead>
            <td>Word</td>
            <td>Count</td>
            <td>Context</td>
            <td></td>
          </thead>
          <tbody>
            <tr v-for="item in trackedWords" :class="{ hidden: item.hidden }">
              <td>{{ item.word }}</td>
              <td>{{ item.count }}</td>
              <td>{{ item.context }}</td>
              <td> <button v-if="!item.hidden" class="btn btn-outline-danger btn-sm"
                  @click="hideWord(item.word, item.context)">Hide</button></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<style scoped>
.hidden {
  text-decoration: line-through;
}
</style>
