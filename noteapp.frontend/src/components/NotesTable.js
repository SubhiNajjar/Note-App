import React, { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { DeleteNote, GetNotes } from '../services/notes';
import { EditNoteModal } from "./NoteModal";
import "./NotesTable.css";



export const NotesTable = () => {
    const notes = useSelector(state => state.notesReducer.notes);
    const dispatch = useDispatch();

    useEffect(() => {
        GetNotes(dispatch);
    }, []);

    return <div class="container">
        <div class="row">{
            notes.map(n =>
                <div key={n.id} class="col-sm-4 mb-3">
                    <div class="card border-info mb-3" style={{ width: '18rem' }}>
                        <div class="card-header text-info">{n.subject}</div>
                        <div class="card-body text-dark">
                            <p class="card-text">
                                {n.reminder}
                            </p>
                            <div class="card-footer bg-transparent">
                                <a style={{ width: '3rem' }}>
                                    <EditNoteModal note={n} />
                                </a>
                                <a class="delete" onClick={() => DeleteNote(dispatch, n)}></a>
                            </div>
                        </div>
                    </div>
                </div>
            )
        }
        </div>

    </div>
}
